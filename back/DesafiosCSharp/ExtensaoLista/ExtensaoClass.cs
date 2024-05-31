namespace ExtensaoLista
{
    public static class ExtensaoClass
    {
        public static void RemoveRepetidos<T>(this List<T> list)
        {
            HashSet<T> seenElements = new HashSet<T>();
            int index = 0;
            while (index < list.Count)
            {
                if (!seenElements.Add(list[index]))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
