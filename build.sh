#!/usr/bin/env bash

# This is just a bootstrap file for loading the main Atlas.Build scripts
# You shouldn't need to change this file. 
# See https://github.com/kinnser/Atlas.Build for more details


# Define directories.
PACKAGE=Atlas.Build
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/Build/tools
INSTALL_DIR="$TOOLS_DIR/$PACKAGE"

# Make sure the tools folder exist.
if [ ! -d "$TOOLS_DIR" ]; then
  mkdir "$TOOLS_DIR"
fi

# Download the Atlas.Build package
MYGET=https://www.myget.org/F/ksi-core/auth/df32a8ba-0288-466a-9401-0cf5ea7f2e6e/api/v2/package
if [ ! -d "$TOOLS_DIR/$PACKAGE" ]; then
    # Make sure unzip is available    
    command -v unzip >/dev/null 2>&1 || { apt-get update; apt-get install -y unzip; }

    echo "Downloading $PACKAGE..."
    curl -Lsfo "$PACKAGE.zip" "$MYGET/$PACKAGE" && unzip -q "$PACKAGE.zip" -d "$INSTALL_DIR" && rm -f "$PACKAGE.zip"
    if [ $? -ne 0 ]; then
        echo "An error occured while installing $PACKAGE."
        exit 1
    fi
fi

# Make sure that Atlas.Build has been installed.
ATLAS_BOOTSTRAP="$INSTALL_DIR/Content/build.sh"
if [ ! -f "$ATLAS_BOOTSTRAP" ]; then
    echo "Could not find Atlas bootstrap at '$ATLAS_BOOTSTRAP'."
    exit 1
fi

# Run the Atlas Bootstrap
bash "$ATLAS_BOOTSTRAP" "$SCRIPT_DIR/Build/build.cake" "$@"
