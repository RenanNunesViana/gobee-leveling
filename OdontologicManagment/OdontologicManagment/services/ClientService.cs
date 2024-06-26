﻿using OdontologicManagment.repository;
using OdontologicManagment.models;
using OdontologicManagment.repositories;

namespace OdontologicManagment.services
{
    internal class ClientService
    {

        private readonly ClientRepo _clientRepo;
        private readonly ConsultaRepo _consultaRepo;

        public ClientService(ApplicationDbContext context)
        {
            _clientRepo = new ClientRepo(context);
            _consultaRepo = new ConsultaRepo(context);
        }


        public Client ResgatarClientePeloId(int id)
        {
            Client? client = _clientRepo.FindById(id);
            if (client != null)
            {
                return client;
            }
            else
            {
                throw new Exception($"Cliente com id {id} não encontrado.");
            }
        }

        public Client? ResgatarClientePeloCpf(String cpf)
        {
            var client = _clientRepo.FindByCpf(cpf);
            if (client != null)
            {
                return client;
            }
            else { throw new Exception($"Erro: paciente não cadastrado"); }
        }

        public void AddClient(Client client)
        {
            // Acho que talvez seja desnecessário pois o DbSet já impede IDs iguais. Pus por desencargo de consciência
            if (_clientRepo.FindById(client.Id) == null)
            {
                LancaExcecaoCpfExistente(client.Cpf);
                _clientRepo.Save(client);
            }
            else
            {
                throw new Exception("Cliente com este ID já existe!");
            }
        }

        public Client RmvClientByCpf(String cpf)
        {
            Client? client = ResgatarClientePeloCpf(cpf);
            if (client != null)
            {
                List<Consulta> consultasFuturas = FindByCpfConsultasFuturas(client.Cpf);
                if (consultasFuturas.Count == 0) 
                {
                _clientRepo.DeleteByCpf(cpf);
                return client;
                }
                else
                {
                    throw new Exception("Erro: paciente está agendado.");
                }
            }
            throw new Exception($"Erro: paciente não cadastrado");
        }

        public List<Consulta> FindByCpfConsultasFuturas(String cpf)
        {
            List<Consulta> consultas = _consultaRepo.FindByCpf(cpf);
            var consultasFuturas = consultas.Where(
                c => c.DataConsulta > DateTime.Now.Date
                    ||
                    (c.DataConsulta == DateTime.Now.Date && c.HoraInicial > DateTime.Now.TimeOfDay)
                ).ToList();

            return consultasFuturas;
        }

        //se ordenação for 0 é por cpf, se for 1 é por nome
        public List<Client> RecuperaClientes(int ordenacao)
        {
            if (ordenacao == 0)
            {
                return _clientRepo.FindAll().OrderBy(c => c.Cpf).ToList();
            }
            else { return _clientRepo.FindAll().OrderBy(c => c.Name).ToList(); }

        }

        private void LancaExcecaoCpfExistente(String cpf)
        {
            
            if (_clientRepo.ClientExists(cpf)) 
                throw new ArgumentException("Erro: CPF já cadastrado");
            
        }
    }
}
