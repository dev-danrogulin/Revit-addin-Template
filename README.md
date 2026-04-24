# Revit Add-in Pattern (2022-2026)

[Русский](#русский) | [English](#english)

---

## Русский

Шаблон Revit-плагина с архитектурным базисом для версий **2022-2026**:

- multi-target сборка: `net48` + `net8.0-windows`
- WPF UI (MVVM)
- Ribbon tab/panel/buttons
- Dockable Pane + обычное WPF окно
- генерация `.addin` и раскладка артефактов по годам

### Что уже есть

- Точка входа Revit: `PluginApp` (`IExternalApplication`)
- Ribbon builder: `Ribbon/RibbonBuilder.cs`
- Команды:
  - `Commands/ShowWindowCommand.cs`
  - `Commands/ShowDockablePaneCommand.cs`
- Dockable infrastructure:
  - `Dockable/DockablePaneIds.cs`
  - `Dockable/MainDockablePaneProvider.cs`
- MVVM foundation:
  - `Infrastructure/Mvvm/ViewModelBase.cs`
  - `Infrastructure/Mvvm/RelayCommand.cs`
- UI:
  - `Views/MainPaneView.xaml`
  - `Views/MainWindow.xaml`
  - `ViewModels/MainPaneViewModel.cs`

### Требования

- Windows
- .NET SDK (рекомендуется 8+)
- Revit 2022-2026

### Сборка под конкретный год

Из корня проекта:

#### Revit 2022
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2022.1.80 -p:RevitYear=2022
```

#### Revit 2023
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2023.1.90 -p:RevitYear=2023
```

#### Revit 2024
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2024.3.40 -p:RevitYear=2024
```

#### Revit 2025
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net8.0-windows -p:RevitApiNet8Version=2025.4.41 -p:RevitYear=2025
```

#### Revit 2026
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net8.0-windows -p:RevitApiNet8Version=2026.4.0 -p:RevitYear=2026
```

### Где лежат артефакты

После сборки:

- `artifacts/<year>/RevitAddin.Plugin.dll`
- `artifacts/<year>/RevitAddin.Plugin.pdb`
- `artifacts/<year>/RevitAddin.Plugin.addin`

### Деплой `.addin` в пользовательскую папку Revit

Добавь флаг:

```powershell
-p:DeployToUserAddins=true
```

Тогда `.addin` копируется в:

`%AppData%\Autodesk\Revit\Addins\<year>\`

### Запуск в Revit

После старта Revit:

1. Открой вкладку `Revit Addin Pattern`
2. В панели `Main` нажми:
   - `Open Window` для обычного WPF окна
   - `Open Dockable Pane` для dockable-pane


---

## English

Revit add-in template for **2022-2026** with a clean architectural baseline:

- multi-target build: `net48` + `net8.0-windows`
- WPF UI (MVVM)
- Ribbon tab/panel/buttons
- Dockable Pane + regular WPF window
- year-based artifacts and `.addin` generation

### Included baseline

- Revit entry point: `PluginApp` (`IExternalApplication`)
- Ribbon builder: `Ribbon/RibbonBuilder.cs`
- Commands:
  - `Commands/ShowWindowCommand.cs`
  - `Commands/ShowDockablePaneCommand.cs`
- Dockable infrastructure:
  - `Dockable/DockablePaneIds.cs`
  - `Dockable/MainDockablePaneProvider.cs`
- MVVM foundation:
  - `Infrastructure/Mvvm/ViewModelBase.cs`
  - `Infrastructure/Mvvm/RelayCommand.cs`
- UI:
  - `Views/MainPaneView.xaml`
  - `Views/MainWindow.xaml`
  - `ViewModels/MainPaneViewModel.cs`

### Requirements

- Windows
- .NET SDK (8+ recommended)
- Revit 2022-2026

### Build by Revit year

Run from repository root:

#### Revit 2022
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2022.1.80 -p:RevitYear=2022
```

#### Revit 2023
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2023.1.90 -p:RevitYear=2023
```

#### Revit 2024
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net48 -p:RevitApiNet48Version=2024.3.40 -p:RevitYear=2024
```

#### Revit 2025
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net8.0-windows -p:RevitApiNet8Version=2025.4.41 -p:RevitYear=2025
```

#### Revit 2026
```powershell
dotnet build .\src\RevitAddin.Plugin\RevitAddin.Plugin.csproj -c Release -f net8.0-windows -p:RevitApiNet8Version=2026.4.0 -p:RevitYear=2026
```

### Artifact output

After build:

- `artifacts/<year>/RevitAddin.Plugin.dll`
- `artifacts/<year>/RevitAddin.Plugin.pdb`
- `artifacts/<year>/RevitAddin.Plugin.addin`

### Deploy `.addin` to Revit user folder

Add:

```powershell
-p:DeployToUserAddins=true
```

This copies `.addin` to:

`%AppData%\Autodesk\Revit\Addins\<year>\`

### Run in Revit

After launching Revit:

1. Open `Revit Addin Pattern` tab
2. In `Main` panel click:
   - `Open Window` for regular WPF window
   - `Open Dockable Pane` for dockable pane

