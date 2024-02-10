namespace AAD;

public class LnkNode<T> where T : notnull
{
    public T Value { get; }
    public LnkNode<T>? Next { get; set; }
<<<<<<< HEAD
    //esto es un constructor... que llama a otro constructor
    public LnkNode(T value) : this(value, null) => 
        Value = value;
    //este es el segundo metodo constructor que recibe el valor y un siguiente nodo (en el caso que sea nuevo, deberia tener null en next,
    //si el nodo no es nuevo y ya habia otro, deberan pasarnos el valor, y un puntero al siguiente nodo, esto, seria llamando a este metodo constructor
    //y no al anterior.
    public LnkNode(T value, LnkNode<T>? next)
=======

    public LnkNode(T value, LnkNode<T>? next = null)
>>>>>>> ae13e8da7ea86944360845aea1026c7fe0406eb9
    {
        Value = value;
        Next = next;
    }

    public bool ValueEquals(T value) => 
        Value.Equals(value);

    public bool NextValueEquals(T value) => 
        Next != null && Next.ValueEquals(value);
}