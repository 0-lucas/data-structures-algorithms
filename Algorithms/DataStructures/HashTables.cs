namespace Algorithms.DataStructures;

// Supports only string and int key values.
public class SimpleHashTable
{
	private object?[] Values;
	
	protected int Length;
	
	public SimpleHashTable(int length)
	{
		Length = length;
		Values = new object[Length];
	}
	
	internal bool IsKeyTypeValid(object key)
	{
		return key is string or int;
	}

	// Not good enough for serious purposes. For studying, it's good enough.
	internal int HashFunction(int number)
	{
		return number % Length;
	}

	internal int HashFunction(string word)
	{
		char[] characters = word.ToCharArray();
		int sum = 0;

		// Sums all ASCII numbers of each character.
		for (int i = 0; i < characters.Length; i++)
		{
			int asciiNumberOfChar = (int)characters[i];
			sum += asciiNumberOfChar;
		}

		return HashFunction(sum);
	}

	internal int HashFunction(object value)
	{
		if (IsKeyTypeValid(value))
		{
			if (value is string)
			{
				var stringValue = value.ToString();
				return HashFunction(stringValue);
			}

			else // value is int
			{
				// C# really asks for this parsing. I also do not like it.
				int? intValue = int.Parse((string)value);
				return HashFunction(intValue);
			}
		}
		else
			throw new Exception("Value type not supported. Try int or string");
	}

	public void Insert(int key, object value)
	{
		int index = HashFunction(key);
		Values[index] = value;
	}

	public void Insert(string key, object value)
	{
		int index = HashFunction(key);
		Values[index] = value;
	}

	internal virtual bool IsIndexEmpty(int index)
	{
		return Values[index] is null;
	}

	public void RemoveFromKey(string key)
	{
		int index = HashFunction(key);
		RemoveAt(index);
	}

	public void RemoveFromKey(int key)
	{
		int index = HashFunction(key);
		RemoveAt(index);
	}

	public void RemoveAt(int index)
	{
		// Index out of bounds are treated by Array class.
		if (!IsIndexEmpty(index))
			Values[index] = null;
	}

	public virtual object Get(string key)
	{
		int index = HashFunction(key);
		return GetAt(index);
	}

	public virtual object Get(int key)
	{
		int index = HashFunction(key);
		return GetAt(index);
	}

	internal virtual object GetAt(int index, object? defaultReturn = null)
	{
		if (!IsIndexEmpty(index))
			return Values[index];

		return defaultReturn;
	}
}

public class HashElement(object key, object value)
{
	public object Key { get; set; } = key;

	public object Value { get; set; } = value;
}

public class LinearProbingHashTable : SimpleHashTable
{
	protected new int Length;

	public HashElement?[] HashValues;
	
	public LinearProbingHashTable(int length) : base(length)
	{
		Length = length;
		HashValues = new HashElement?[Length];
	}
	
	public new void Insert(int key, object value)
	{
		int firstIndex = HashFunction(key);
		HashElement valueToInsert = new(key, value);

		ProbingInsert(firstIndex, valueToInsert);
	}

	public new void Insert(string key, object value)
	{
		int firstIndex = HashFunction(key);
		HashElement valueToInsert = new(key, value);

		ProbingInsert(firstIndex, valueToInsert);
	}

	private void ProbingInsert(int firstIndex, HashElement value)
	{
		int index = firstIndex;

		bool firstCheck = true;
		while (!IsIndexEmpty(index))
		{
			index++;
			index = HashFunction(index);
			
			// Prohibits duplicate keys
			if (HashValues[index]?.Key.Equals(value.Key) ?? false)
				throw new Exception("Duplicates keys not permitted.");
			
			if (index == firstIndex & !firstCheck)
			{
				// Doubles table size, then starts insertion on last filled index ( half of new size ).
				Resize();
				ProbingInsert(Length / 2, value);
				return;
			}
			
			firstCheck = false;
		}
		HashValues[index] = value;
	}

	// Increases size of values array and length field
	private void Resize()
	{
		Length *= 2;
		Array.Resize(ref HashValues, Length);
	}

	internal override bool IsIndexEmpty(int index)
	{
		return HashValues[index] is null;
	}
	
	internal override object GetAt(int index, object? defaultReturn = null)
	{
		if (!IsIndexEmpty(index))
			return HashValues[index].Value;

		return defaultReturn;
	}

	public override object Get(int key)
	{
		int firstIndex = HashFunction(key);
		return ProbingGet(firstIndex, key);

	}

	public override object Get(string key)
	{
		int firstIndex = HashFunction(key);
		return ProbingGet(firstIndex, key);
	}

	private object ProbingGet(int firstIndex, object originalKey)
	{
		int index = firstIndex;
	
		bool firstCheck = true;
		while (!IsIndexEmpty(index))
		{
			HashElement? element = HashValues[index];
	
			// Key found with original key. Returns value
			if (HashValues[index]?.Key.Equals(originalKey) ?? false)
				return GetAt(index); 
			
			
			if (index == firstIndex && !firstCheck)  // Checked the entire table
			{	
				return null;
			}
			
			index++;
			firstCheck = false;
		}
	
		return null;
	}
}