dotnet test --filter "UC=Caso de uso XPTO"

git rm -r --cached bin/
git rm -r --cached obj/
git commit -m "Remove bin and obj directories from the repository"
