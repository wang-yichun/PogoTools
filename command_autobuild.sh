S0="${BASH_SOURCE[0]}"
DIRNAME="$( dirname "$S0")"
DIR="$( cd "$DIRNAME" && pwd)"

echo $S0
echo $DIRNAME
echo $DIR

cd `dirname $0`
/Library/Frameworks/Mono.framework/Versions/4.6.1/bin/xbuild /p:Configuration=Release PogoTools.sln
./command_after_build.sh
echo "Update dll succeed."