using GitCommands.Models;

namespace GitCommands.Services;

public static class CommandsService
{
    static List<Command> Commands { get; }
    static int nextId = 16;
    static CommandsService()
    {
        Commands = new List<Command>
        {
            new Command { 
              Id = 1,
              Instruction = "git status", 
              Description="Checa o status" },
            new Command {
              Id = 2, 
              Instruction = "git add [nome-arquivo.txt]", 
              Description="Adiciona um arquivo para área de stage" },
            new Command {
              Id = 3, 
              Instruction = "git commit -m [Mensagem de Commit]", 
              Description="Comita as alterações" },
            new Command {
              Id = 4, 
              Instruction = "git rm -r [nome-arquivo.txt]", 
              Description="Remove um arquivo (ou pasta)" },
            new Command {
              Id = 5, 
              Instruction = "git branch", 
              Description="Lista as branches (o asterisco denota a branch atual)" },
            new Command {
              Id = 6, 
              Instruction = "git branch -a", 
              Description="Lista todas as branches (local e remoto)" },
            new Command {
              Id = 7, 
              Instruction = "git branch [nome da branch]", 
              Description="Cria uma nova branch" },
            new Command {
              Id = 8, 
              Instruction = "git branch -d [nome da branch]", 
              Description="Deleta uma branch" },
            new Command {
              Id = 9, 
              Instruction = "git push origin --delete [nome da branch]", 
              Description="Deleta uma branch remota" },
            new Command {
              Id = 10, 
              Instruction = "git checkout -b [nome da branch]", 
              Description="Cria uma nova branch e muda para ela" },
            new Command {
              Id = 11, 
              Instruction = "git checkout -b [nome da branch] origin/[nome da branch]", 
              Description="Clona uma branch remota e muda para ela" },
            new Command {
              Id = 12, 
              Instruction = "git checkout [nome da branch]", 
              Description="Seleciona uma branch" },
            new Command {
              Id = 13, 
              Instruction = "git checkout -", 
              Description="Muda para a última branch" },
            new Command {
              Id = 14, 
              Instruction = "git checkout -- [nome-arquivo.txt]", 
              Description="Descarta modificações de um arquivo" },
            new Command {
              Id = 15, 
              Instruction = "git merge [nome da branch]", 
              Description="Faz um merge de uma branch na branch atual" },
      };
    }

    public static List<Command> GetAll() => Commands;

    public static Command? Get(int id) => Commands.FirstOrDefault(p => p.Id == id);

    public static void Add(Command Command)
    {
        Command.Id = nextId++;
        Commands.Add(Command);
    }

    public static void Delete(int id)
    {
        var Command = Get(id);
        if(Command is null)
            return;

        Commands.Remove(Command);
    }

    public static void Update(Command Command)
    {
        var index = Commands.FindIndex(p => p.Id == Command.Id);
        if(index == -1)
            return;

        Commands[index] = Command;
    }
}