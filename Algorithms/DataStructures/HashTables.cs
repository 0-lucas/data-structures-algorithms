using System.Windows.Markup;

namespace Algorithms.DataStructures;

// Supports only string and int key values.
public class HashTable(int lenght)
{
	public int Lenght = lenght;

	public Object?[] values = new object[lenght];

	// Not good enough for serious purposes. For studying, it's good enough.
	private int HashFunction(int number)
	{
		return number % Lenght;
	}

	private int HashFunction(string word)
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

	public void Insert(int key, object value)
	{
		int index = HashFunction(key);
		values[index] = value;
	}

	public void Insert(string key, object value)
	{
		int index = HashFunction(key);
		values[index] = value;
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
		if (values[index] != null)
			values[index] = null;

		else
			throw new Exception("No value found");
	}

	public object Get(string key)
	{
		int index = HashFunction(key);
		return GetAt(index);
	}

	public object Get(int key)
	{
		int index = HashFunction(key);
		return GetAt(index);
	}

	private object GetAt(int index)
	{
		if (values[index] != null)
			return values[index];

		else
			throw new Exception("No value found");
	}
}
