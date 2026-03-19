// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
using System.Threading.Tasks;
using System;

public class HelloWorld
{
    public static void  Main(string[] args)
    {
       // Inline chaining if AddListNode returns the updated list
       var obj = new ReverseLinkedList()
              .AddListNode(1)
              .AddListNode(2)
              .AddListNode(3)
              .AddListNode(4);
              
              

        
        Node rev= ReverseLinkedList.reverseLinkedList(obj.head);
        
        if(rev!=null)
        {
            Console.WriteLine(rev.val);
            while(rev.next!=null)
            {
            Console.WriteLine(rev.next.val);
            rev=rev.next;
            }
        }
    }
}
public class Node
{
  public int val=0;
  public Node next=null;
  public Node(int val)
  {
      this.val=val;
      this.next=null;
  }
}

public class ReverseLinkedList
{
    public Node head=null;
    Node current= null;
    
  public ReverseLinkedList AddListNode(int i)
{
    Node newNode = new Node(i);
    if (this.head == null)
    {
        this.head = newNode;
    }
    else
    {
        Node current = this.head;
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = newNode;
    }
    return this; // return the list object, not the node
}

    
    public static Node reverseLinkedList(Node head)
    {
        Node prev=null;
        Node curr=head;
        
        while(curr!=null)
        {
            Node next=curr.next;
            curr.next=prev;
            prev=curr;
            curr=next;
        }
        return prev;
    }
    
}








