# 🎭 MVPAutomation - Framework de Testes E2E

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=.net)
![Playwright](https://img.shields.io/badge/Playwright-1.58.0-blue?style=for-the-badge&logo=microsoft)
![NUnit](https://img.shields.io/badge/NUnit-3.14.0-darkgreen?style=for-the-badge)
![Allure](https://img.shields.io/badge/Allure-Report-orange?style=for-the-badge)

**Framework robusto de automação de testes E2E utilizando arquitetura MVP e design patterns de alta qualidade**

[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

</div>

---

## 📋 Índice

-[Link Relatório do Allure: https://gitleviss.github.io/MVPAutomation/allure-report/]

- [🎯 Sobre o Projeto](#-sobre-o-projeto)
- [🚀 Tecnologias e Ferramentas](#-tecnologias-e-ferramentas)
- [🏗️ Arquitetura](#️-arquitetura)
- [🎨 Design Patterns Aplicados](#-design-patterns-aplicados)
- [📁 Estrutura do Projeto](#-estrutura-do-projeto)
- [⚡ Como Executar](#-como-executar)
- [📊 Relatórios Allure](#-relatórios-allure)
- [💡 Benefícios da Automação E2E](#-benefícios-da-automação-e2e)
- [🔧 Configurações](#-configurações)

---

## 🎯 Sobre o Projeto

O **MVPAutomation** é um framework moderno e escalável para automação de testes End-to-End (E2E), desenvolvido em C#/.NET 8.0. O projeto utiliza a arquitetura **MVP (Model-View-Presenter)** adaptada para automação de testes, proporcionando uma estrutura organizada, manutenível e fácil de expandir.

### Cenários Cobertos

✅ **Autenticação de Usuários**
- Login com credenciais válidas
- Validação de campos obrigatórios
- Validação de formato de e-mail
- Validação de senha incorreta

✅ **Registro de Novos Usuários**
- Cadastro completo com sucesso
- Validação de campos obrigatórios (nome e sobrenome)
- Validação de confirmação de senha

✅ **Fluxo de Compras**
- Adição de produtos ao carrinho
- Checkout completo
- Validação de endereços
- Processamento de pagamento
- Confirmação de pedido

---

## 🚀 Tecnologias e Ferramentas

### Core

| Tecnologia | Versão | Descrição |
|------------|--------|-----------|
| **.NET** | 8.0 | Plataforma de desenvolvimento principal |
| **C#** | 12 | Linguagem de programação |

### Frameworks de Automação

| Ferramenta | Versão | Descrição |
|-------------|--------|-----------|
| **Microsoft Playwright** | 1.58.0 | Biblioteca de automação de navegador moderna |
| **NUnit** | 3.14.0 | Framework de testes unitários |
| **Microsoft.Playwright.NUnit** | 1.58.0 | Integração Playwright + NUnit |

### Relatórios e Monitoramento

| Ferramenta | Versão | Descrição |
|-------------|--------|-----------|
| **Allure.Net.Commons** | 2.14.1 | Geração de relatórios detalhados |
| **Allure.NUnit** | 2.14.1 | Integração Allure com NUnit |

### Configuração e Utilitários

| Ferramenta | Versão | Descrição |
|-------------|--------|-----------|
| **Microsoft.Extensions.Configuration** | 9.0.9 | Gerenciamento de configurações |
| **Microsoft.Extensions.Configuration.Json** | 9.0.9 | Suporte a arquivos JSON |
| **Microsoft.NET.Test.Sdk** | 17.8.0 | SDK de testes |

---

## 🏗️ Arquitetura

```
MVPAutomation/
├── 📁 interfaces/        # Contratos e abstrações (Interfaces)
├── 📁 pages/            # Páginas (View/Presenter do MVP)
├── 📁 locators/        # Seletores CSS/XPath separados
├── 📁 data/            # Modelos de dados (Model do MVP)
├── 📁 utils/           # Utilitários e helpers
├── 📁 tests/           # Casos de teste
├── 📁 runner/          # Base de testes e configuração
└── 📁 videos/          # Gravações de execução
```

### Camadas da Arquitetura

#### 1. **Interface Layer** (`interfaces/`)
Define contratos que garantem desacoplamento e testabilidade:
- `IPageBase` - Contrato base para páginas
- `IActions` - Contrato para ações de interação
- `IValidator` - Contrato para validações
- `IBaseTest` - Contrato base para testes

#### 2. **Model Layer** (`data/`)
Contém os modelos de dados utilizados nos testes:
- `LoginData` - Credenciais de login
- `RegisterData` - Dados de registro de usuário

#### 3. **View/Presenter Layer** (`pages/`)
Implementações das páginas following Page Object Model:
- `BasePage` - Classe abstrata base
- `LoginPage` - Página de autenticação
- `RegisterPage` - Página de registro
- `ShoppingCartPage` - Carrinho de compras
- `BooksPage` - Catálogo de livros

#### 4. **Locator Layer** (`locators/`)
Separação de seletores para fácil manutenção:
- `LoginLocators` - Seletores de login
- `RegisterLocators` - Seletores de registro
- `ShoppingCartLocators` - Seletores do carrinho
- `HomePageLocators` - Seletores da home

#### 5. **Utility Layer** (`utils/`)
Classes utilitárias reutilizáveis:
- `Actions` - Encapsula ações do Playwright
- `Validators` - Encapsula validações/asserções
- `VideoHelper` - Gerenciamento de vídeos
- `VideoUtils` - Utilitários de vídeo

#### 6. **Test Layer** (`tests/`)
Casos de teste organizados por funcionalidade:
- `BaseTest` - Configuração base de testes
- `LoginTests` - Testes de autenticação
- `RegisterTests` - Testes de registro
- `ShoppingCartTests` - Testes de compras

#### 7. **Runner Layer** (`runner/`)
Configuração e inicialização do framework:
- `TestBase` - Base de configuração do Playwright

---

## 🎨 Design Patterns Aplicados

### 1. **Page Object Model (POM)**
Separa a lógica de teste da lógica de interação com a página.

```csharp
// Page
public class LoginPage : BasePage
{
    public async Task DoLogin()
    {
        await _actions.ClickAsync(_home.LogInButton, "...");
        await _actions.FillAsync(_login.EmailField, _data.Email, "...");
    }
}

// Test
[Test]
public async Task ShouldDoLoginSuccessfull()
{
    var login = new LoginPage(_page, _actions);
    await login.DoLogin();
}
```

### 2. **Dependency Injection (DI)**
Injeção de dependências via construtores para facilitar testes e desacoplamento.

```csharp
public LoginPage(IPage page, IActions actions, LoginData data = null)
    : base(page, actions)
{
    _data = data ?? new LoginData();
}
```

### 3. **Template Method Pattern**
Define o esqueleto de um algoritmo, permitindo subclasses redefinirem certos passos.

```csharp
public abstract class BasePage : IPageBase
{
    protected BasePage(IPage page, IActions actions)
    {
        _page = page;
        _actions = actions;
    }
}

public class LoginPage : BasePage
{
    // Implementação específica
}
```

### 4. **Strategy Pattern**
Permite que algoritmos variáveis sejam encapsulados e intercambiáveis.

```csharp
public interface IActions
{
    Task FillAsync(string locator, string text, string step);
    Task ClickAsync(string locator, string step);
}

public class Actions : IActions
{
    // Implementação concreta
}
```

### 5. **Single Responsibility Principle (SRP)**
Cada classe tem uma única responsabilidade bem definida.

- `Actions` - Apenas executa ações
- `Validators` - Apenas valida
- `Pages` - Apenas representa páginas
- `Locators` - Apenas define seletores

### 6. **Interface Segregation Principle (ISP)**
Interfaces pequenas e focadas:

```csharp
public interface IValidator
{
    Task ValidateUrl(string expectedUrl, string step);
    Task LocatorToBeVisibleAsync(string locator, string step);
    Task LocatorToHaveTextAsync(string locator, string expectedText, string step);
}
```

### 7. **Open/Closed Principle (OCP)**
Classes abertas para extensão, fechadas para modificação.

```csharp
// Nova página pode ser adicionada sem modificar classes existentes
public class NewPage : BasePage
{
    // Nova implementação
}
```

---

## 📁 Estrutura do Projeto

### Detalhamento de Arquivos

```
MVPAutomation/
│
├── 📄 MVPAutomation.csproj          # Configuração do projeto e dependências
├── 📄 MVPAutomation.sln             # Solution do projeto
├── 📄 appsettings.json              # Configurações da aplicação (URLs, etc)
├── 📄 allureConfig.json             # Configuração do relatório Allure
│
├── 📁 interfaces/
│   ├── IPageBase.cs                 # Interface base de páginas
│   ├── IActions.cs                  # Interface de ações
│   ├── IValidator.cs                # Interface de validações
│   └── IBaseTest.cs                 # Interface base de testes
│
├── 📁 pages/
│   ├── BasePage.cs                  # Classe abstrata base
│   ├── LoginPage.cs                 # Página de login
│   ├── RegisterPage.cs              # Página de registro
│   ├── ShoppingCartPage.cs          # Página do carrinho
│   └── BooksPage.cs                 # Página de livros
│
├── 📁 locators/
│   ├── LoginLocators.cs             # Seletores CSS/XPath de login
│   ├── RegisterLocators.cs          # Seletores de registro
│   ├── ShoppingCartLocators.cs      # Seletores do carrinho
│   ├── BooksLocators.cs             # Seletores de livros
│   └── HomePageLocators.cs          # Seletores da home
│
├── 📁 data/
│   ├── LoginData.cs                 # Modelo de dados de login
│   └── RegisterData.cs              # Modelo de dados de registro
│
├── 📁 utils/
│   ├── Actions.cs                   # Ações do Playwright encapsuladas
│   ├── Validators.cs               # Validações encapsuladas
│   ├── VideoHelper.cs               # Gerenciamento de vídeos
│   └── VideoUtils.cs                # Utilitários de vídeo
│
├── 📁 tests/
│   ├── BaseTest.cs                  # Configuração base dos testes
│   ├── LoginTests.cs                # Testes de autenticação
│   ├── RegisterTests.cs             # Testes de registro
│   └── ShoppingCartTests.cs         # Testes de compras
│
└── 📁 runner/
    └── TestBase.cs                  # Configuração do Playwright
```

---

## ⚡ Como Executar

### Pré-requisitos

- **.NET 8.0 SDK** ou superior
- **Visual Studio 2022** ou **VS Code**
- **Git**

### Instalação

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/MVPAutomation.git
cd MVPAutomation

# Restaure as dependências
dotnet restore

# Instale os browsers do Playwright
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
```

### Executar os Testes

```bash
# Executar todos os testes
dotnet test

# Executar com verbosidade
dotnet test --logger "console;verbosity=detailed"

# Executar filtros específicos
dotnet test --filter "FullyQualifiedName~LoginTests"
dotnet test --filter "Category=CI"
```

### Executar em Paralelo

O projeto já está configurado para execução paralela:

```csharp
[Parallelizable(ParallelScope.Self)]
public class LoginTests : BaseTest
```

---

## 📊 Relatórios Allure

### Gerar Relatório

```bash
# Após executar os testes
dotnet test

# Gerar o relatório
allure generate allure-results --clean -o allure-report

# Abrir o relatório
allure open allure-report
```

### Características do Relatório

✅ **Detalhes Completes**
- Nome e descrição dos testes
- Status de execução
- Tempo de duração

✅ **Anexos**
- 📹 Vídeos de execução (MP4)
- 📸 Screenshots automáticos
- 📝 Logs detalhados

✅ **Organização**
- Suites funcionais
- Severidade dos testes
- Responsáveis (Owner)

✅ **Métricas**
- Taxa de sucesso
- Tempo total
- Histórico de execuções

### Exemplo de Anotações Allure

```csharp
[AllureOwner("Levi QA")]
[AllureNUnit]
[Parallelizable(ParallelScope.Self)]
[AllureSeverity(SeverityLevel.critical)]
[AllureSuite("Login UI")]
public class LoginTests : BaseTest
{
    [Test]
    [AllureName("Should do login successfull")]
    public async Task ShouldDoLoginSuccessfull()
    {
        // ...
    }
}
```

---

## 💡 Benefícios da Automação E2E

### 🎯 **Validação Completa do Fluxo do Usuário**

Testes E2E validam todo o fluxo desde o início até o fim, simulando interações reais do usuário através de múltiplas camadas da aplicação (frontend, backend, banco de dados, APIs externas).

**Exemplo do Projeto:**
```csharp
// Fluxo completo: Login → Selecionar Produto → Adicionar ao Carrinho → Checkout
await _login.DoLogin();
await books.AddBookOnCart();
await shoppingCart.OpenShoppingCart();
await shoppingCart.ClickOnCheckout();
// Validação final da ordem completa
```

### 🔄 **Detecção de Regressões**

Detecta quebras em funcionalidades existentes causadas por novas mudanças no código, garantindo que features que funcionavam continuem funcionando.

**Benefício:** Evita que bugs regressem para produção.

### ⏱️ **Economia de Tempo e Recursos**

**Antes da Automação:**
- 1 fluxo E2E ≈ 30-60 minutos manualmente
- Execução em todos os browsers ≈ 2-3 horas

**Com Automação:**
- Mesmo fluxo ≈ 2-5 minutos
- Execução paralela em múltiplos browsers ≈ 5-10 minutos
- **Ganho: 80-90% de economia de tempo**

### 🚀 **Feedback Rápido**

Resultados imediatos após cada mudança no código, permitindo correções rápidas antes que bugs cheguem em produção.

```csharp
// Resultado em segundos em vez de horas
dotnet test
// ✓ LoginTests.ShouldDoLoginSuccessfull (2.3s)
// ✗ RegisterTests.ShouldRegisterUserSuccessfull (1.8s) FAILED
```

### 🎲 **Cobertura de Cenários Complexos**

Permite testar combinações de dados, diferentes usuários, múltiplos browsers e dispositivos que seriam impraticáveis manualmente.

**Exemplo do Projeto:**
```csharp
// Múltiplos cenários de teste em uma execução
[Test, Order(1)] public async Task ShouldDoLoginSuccessfull()
[Test, Order(2)] public async Task ShouldntDoLoginWithEmptyFields()
[Test, Order(3)] public async Task ShouldntDoLoginWithInvalidEmail()
[Test, Order(4)] public async Task ShouldntDoLoginWithInvalidPassword()
```

### 🌐 **Cross-Browser Testing**

Executa testes simultaneamente em diferentes browsers (Chrome, Firefox, Safari, Edge) garantindo consistência.

```csharp
// O Playwright suporta múltiplos browsers nativamente
await _playwright.Chromium.LaunchAsync(launchOptions);
await _playwright.Firefox.LaunchAsync(launchOptions);
await _playwright.Webkit.LaunchAsync(launchOptions);
```

### 📝 **Documentação Viva**

Os testes funcionam como documentação executável dos requisitos, mostrando exatamente como a aplicação deve se comportar.

```csharp
// O próprio nome do teste documenta o requisito
[AllureName("Shouldn´t register user with name and last name empty")]
public async Task ShouldntRegisterUserWithoutNameAndLastName()
{
    // Implementação que valida o requisito
}
```

### 🤖 **Integração CI/CD**

Permite integração contínua executando testes automaticamente em cada commit ou pull request.

**Pipeline Exemplo:**
```yaml
# GitHub Actions / Azure DevOps / Jenkins
- name: Run E2E Tests
  run: dotnet test --logger "trx;LogFileName=test-results.trx"

- name: Generate Allure Report
  run: allure generate allure-results --clean -o allure-report

- name: Upload Report
  uses: actions/upload-artifact@v2
  with:
    name: allure-report
    path: allure-report/
```

### 💰 **Retorno Sobre Investimento (ROI)**

**Métricas do Projeto:**
- **Tempo de Setup:** ~2 semanas
- **Manutenção Mensal:** ~4-8 horas
- **Economia por Sprint:** ~40-60 horas de testes manuais
- **ROI em 3 meses:** 300-400%

### 🛡️ **Qualidade e Confiança no Deploy**

Deploy com confiança sabendo que testes E2E validaram os principais fluxos críticos da aplicação.

```csharp
[AllureSeverity(SeverityLevel.critical)]
public class LoginTests : BaseTest
{
    // Fluxos críticos bloqueiam deploy se falharem
}
```

### 📈 **Métricas e Insights**

Gera métricas valiosas sobre qualidade do software:
- Taxa de sucesso por feature
- Tempo de resposta médio
- Tendências de qualidade ao longo do tempo

---

## 🔧 Configurações

### appsettings.json

```json
{
  "Links": {
    "tricentis": "https://demowebshop.tricentis.com/"
  }
}
```

### Variáveis de Ambiente

```bash
# Override do link da aplicação
export APP_LINK="https://qa.tricentis.com/"
```

### Configuração do Playwright

```csharp
// Viewport configurado para 1920x1080
ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }

// Gravação de vídeo habilitada
RecordVideoDir = videosDir
RecordVideoSize = new RecordVideoSize { Width = 1366, Height = 768 }

// Timeouts configurados
SetDefaultTimeout(60000)
SetDefaultNavigationTimeout(60000)
```

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Por favor:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

<div align="center">

**Desenvolvido com ❤️ pela Equipe de QA**

**⭐ Se este projeto foi útil, dê uma estrela! ⭐**

[⬆ Voltar ao topo](#-mvpautomation---framework-de-testes-e2e)

</div>
