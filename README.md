# poy-template-dotnet
A Peaks of Yore mod template for `dotnet new`.

# Installing
```sh
dotnet new install ./template/
```

# Viewing Help
```sh
dotnet new poy-mod -h
# Or
dotnet new poy-mod --help
```

# Generating
```sh
# Basic usage
dotnet new poy-mod --mod-author "GitHub Username" -o "My Mod"

# Disable Mod Menu integration
dotnet new poy-mod --mod-author "GitHub Username" -o "My Mod" \
    --modmenu false

# Disable UILib integration
dotnet new poy-mod --mod-author "GitHub Username" -o "My Mod" \
    --uilib false

# Disable Mod Menu and UILib, but generate with a logger
dotnet new poy-mod --mod-author "GitHub Username" -o "My Mod" \
    --modmenu false --uilib false --logger
```

# Uninstalling
```sh
dotnet new uninstall ./template/
```
