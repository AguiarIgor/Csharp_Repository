using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;
var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);

Console.WriteLine("Qual a database: ");
var modelName = Console.ReadLine();
if(modelName == "Cliente")
{
    Console.WriteLine("Qual o comando: ");
    var modelAction = Console.ReadLine();
    if(modelAction == "List")
    {
        Console.WriteLine("Cliente List");
        foreach (var cliente in clienteRepository.GetAll())
        {
            Console.WriteLine($"{cliente.ClienteId}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais}, {cliente.Telefone}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Qual o Id: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual o Endereço: ");
        string endereco = Console.ReadLine();
        Console.WriteLine("Qual a Cidade: ");
        string cidade = Console.ReadLine();
        Console.WriteLine("Qual a Região: ");
        string regiao = Console.ReadLine();
        Console.WriteLine("Qual o Codigo Postal: ");
        string codigopostal = Console.ReadLine();
        Console.WriteLine("Qual o País: ");
        string pais = Console.ReadLine();
        Console.WriteLine("Qual o Telefone: ");
        string telefone = Console.ReadLine();
        Console.WriteLine("Cliente New");
        var cliente = new Cliente(clienteid, endereco, cidade, regiao, codigopostal, pais, telefone);
        clienteRepository.Save(cliente);
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Cliente Show");
        int clienteid = Convert.ToInt32(Console.ReadLine());

        if(clienteRepository.ExitsById(clienteid))
        {
            var cliente = clienteRepository.GetById(clienteid);
            Console.WriteLine($"{cliente.ClienteId}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais}, {cliente.Telefone}");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
    }
}

if(modelName == "Pedido")
{
    Console.WriteLine("Qual o comando: ");
    var modelAction = Console.ReadLine();
    if(modelAction == "List")
    {
        Console.WriteLine("Pedido List");
        foreach (var pedido in pedidoRepository.GetAll())
        {
            Console.WriteLine($"{pedido.PedidoId}, {pedido.EmpregadoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Qual o Id: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual o Id do Empregado: ");
        int empregoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual a Data do Pedido: ");
        string dataPedido = Console.ReadLine();
        Console.WriteLine("Qual o Peso do Pedido: ");
        string peso = Console.ReadLine();
        Console.WriteLine("Qual o Código da Transportadora: ");
        int codTransportadora = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual o Id do Cliente que fez o Pedido: ");
        int pedidoClienteId = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(pedidoId, empregoId, dataPedido, peso, codTransportadora, pedidoClienteId);
        pedidoRepository.Save(pedido);
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Pedido Show");
        Console.WriteLine("Qual o Id: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());

        if(pedidoRepository.ExitsById(pedidoId))
        {
            var pedido = pedidoRepository.GetById(pedidoId);
            Console.WriteLine($"{pedido.PedidoId}, {pedido.EmpregadoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id {pedidoId} não existe.");
        }
    }
}
