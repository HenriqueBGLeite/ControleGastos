# 🧰 Controle Gastos

Sistema desenvolvido com .NET MAUI, SQLite e Entity Framework, seguindo os princípios da Clean Architecture para garantir organização, manutenção e escalabilidade.

---

## 🧰 Tecnologias Utilizadas

- **MAUI**: Interface de usuário multiplataforma.
- **SQLite**: Banco de dados local.
- **Entity Framework**: ORM para manipulação de dados.
---

## 🗃️ Criando nova versão do banco de dados
## Colocar o projeto Database.Migration.Runtime como projeto de inicialização
## No Console do Gerenciador de Pacotes, colocar o projeto padrão como Data\Database

```bash
# A partir da raiz do projeto:
Add-Migration <NomeDaMigracao>

# Para edições, após criar a nova migração, executar:
Update-Database

```
---