using System;

using AuditText;

namespace MashinePostaLogic;


class Post{
    static void Main(string[] args){
        Console.WriteLine("Ведіть");
        string? text = Console.ReadLine();
        Audit audit = new Audit();
        string? respondAuditText = audit.AuditTextCeker(text);

        Console.WriteLine(respondAuditText);




    }
}

