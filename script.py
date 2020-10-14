from os import getcwd, scandir, listdir, system, rmdir, remove
from os.path import join, isfile
from re import split
from shutil import move

directory = getcwd()
childs = [x.path for x in scandir(
    directory) if x.is_dir() and x.name != '.vscode']

for child in childs:
    childs_of_child = [x.path for x in scandir(child) if x.is_dir()]
    for c in childs_of_child:
        files = [f for f in listdir(c) if isfile(join(c, f))]
        # dir_name = [f.split(".cpp")[0] for f in listdir(
        #     c) if isfile(join(c, f)) and ".cpp" in f][0]
        project_name = ''.join(fn.capitalize()
                               for fn in split("[-_]", [f.split(".cpp")[0] for f in files if ".cpp" in f][0]))

        print(f"Create project {project_name}")
        system(f"dotnet new console -o {project_name}")
        for f in files:
            file = join(c, f)
            print(f"Delete file {file}")
            remove(file)
        print(
            f"Move project: {join(directory, project_name)} to {c}")
        project_path = join(directory, project_name)
        for f in listdir(project_path):
            if "program" in f.lower():
                move(join(project_path, f), join(c, project_name+".cs"))    
            else:
                move(join(project_path, f), join(c, f))
        print("Remove empty dir")
        rmdir(project_path)
