# Fifa2026


<img width="1251" height="481" alt="image" src="https://github.com/user-attachments/assets/2f986108-b8e8-4bd2-abfa-f4ddcab7b8b5" />

Navegue até o diretório raiz do IIS, localizado em C:\inetpub\wwwroot. Copie as pastas "API" e "Web" para dentro deste diretório. Cada uma dessas pastas representa uma camada distinta da aplicação, sendo a pasta "Web" responsável pelo frontend e a pasta "API" responsável pelo backend. Aguarde a conclusão da cópia de todos os arquivos.

Vai ter duas máquinas virtuais trabalhando em duas zonas diferentes para ter arredundância para a gente garantir um nível maior de disponibilidade a gente vai ter um Network que você curte grupo fazendo a proteção dessa subnete então é uma VNet com uma subtinete duas máquinas de aplicação porém agora a gente vai ter uma camada mais para trabalhar qual que é essa camada uma camada de data mês então a gente vai ter um SQL e Cérebro rodando dentro de uma máquina, trazer o SQL server por uma outra VNet faz com que quando nós trabalhamos com VNets. As VNet por padrão não se comunicam então se eu tenho a minha VNet 001 aqui e a minha a minha outra ferramenta também é 001 Mas ela tá numa região diferente mas eu vou chamar de VNet de aplicação internet de banco Creia as duas janelas elas não vão se comunicar ela só vão se comunicar quando que quando a gente criar um filho entre as duas venéticas.

Primeiro ponto a gente vai construir toda essa estrutura de rede completa depois a gente vai jogar as nossas máquinas e aí a gente vai ter um bom trabalho configurando a aplicação essas máquinas e depois disso a gente vai trabalhar com um outro formato de balanceador de rede não vai ser Load Balancer ele vai ser o Application Gateway E aí a gente vai colocar alguns pontos adicionais no Application Gateway para vocês entenderem e conseguirem tirar o melhor proveito e enxergar visualmente como que é a maior diferença do Application Gateway com o Load Balancer ele vai ficar bem claro para vocês e por que que o Application Gateway ele é tão importante principalmente né ele vai funcionar tanto interno quanto externo Mas por que que ele é tão importante principalmente para publicar aplicações para a rua ok.


1. **VNet 01 - Canada Central**
   - 2 VMs de Aplicação (Availability Zones)
   - Subnet de Aplicação
   - NSG

2. **VNet 02 - US East**  
   - 1 VM SQL Server
   - Subnet de Database
   - NSG

3. **VNet Peering Global**
   - Conecta VNet 01 ↔ VNet 02
   - Permite comunicação App ↔ Database

4. **Application Gateway**
   - Substitui o Load Balancer
   - Camada 7 (HTTP/HTTPS)
   - SSL Offloading
   - Roteamento baseado em URL

### Etapas do Projeto

Então é dessa forma que a gente vai trabalhar:

1. **Construir estrutura de rede completa**
   - Criar VNets em 2 regiões
   - Configurar subnets
   - Estabelecer VNet Peering

2. **Deploy das máquinas virtuais**
   - 2 VMs de Aplicação
   - 1 VM SQL Server

3. **Configurar aplicação**
   - Instalar backend/frontend
   - Conectar com SQL Server
   - Testar conectividade

4. **Implementar Application Gateway**
   - Configurar backend pools
   - Criar regras de roteamento
   - Configurar health probes
   - Comparar com Load Balancer

---

| Característica | Projeto 01 | Projeto 02 |
|----------------|------------|------------|
| **VNets** | 1 VNet | 2 VNets (Peering) |
| **Regiões** | 1 Região | 2 Regiões |
| **VMs** | 2 VMs App | 2 VMs App + 1 VM DB |
| **Banco de Dados** | ❌ Não | ✅ SQL Server |
| **Balanceador** | Load Balancer (L4) | Application Gateway (L7) |
| **Aplicação** | Frontend simples | Frontend + Backend + DB |
| **Complexidade** | Básica | Intermediária |
| **Conta Trail** | ✅ Sim | ✅ Sim (com adaptações) |

---

### Próximos Passos

1. Deploy da infraestrutura de rede
2. Configuração do VNet Peering
3. Criação das máquinas virtuais
4. Instalação do SQL Server
5. Deploy da aplicação
6. Configuração do Application Gateway
7. Testes de alta disponibilidade

---


