all : wraps AgentDemo\AgentDemo.exe HelloWorld\HelloWorld.exe "Interactive HelloWorld\HelloWorld Interact.exe"

wraps :
  aximp %%systemroot%\msagent\agentctl.dll
  copy *.dll AgentDemo
  copy *.dll HelloWorld
  copy *.dll "Interactive HelloWorld"
  del *.dll

AgentDemo\AgentDemo.exe : AgentDemo\AgentDemo.cs AgentDemo\AssemblyInfo.cs
  cd AgentDemo
  csc /target:winexe /debug+ /warn:4 /r:AxAgentObjects.dll /r:AgentObjects.dll /out:AgentDemo.exe AgentDemo.cs AssemblyInfo.cs
  cd ..

HelloWorld\HelloWorld.exe : HelloWorld\HelloWorld.cs HelloWorld\AssemblyInfo.cs
  cd HelloWorld
  csc /target:winexe /debug+ /warn:4 /r:AxAgentObjects.dll /r:AgentObjects.dll /out:HelloWorld.exe HelloWorld.cs AssemblyInfo.cs
  cd ..

"Interactive HelloWorld\HelloWorld Interact.exe" : "Interactive HelloWorld\HelloWorldInteract.cs" "Interactive HelloWorld\AssemblyInfo.cs"
  cd "Interactive HelloWorld"
  csc /target:winexe /debug+ /warn:4 /r:AxAgentObjects.dll /r:AgentObjects.dll /out:"HelloWorld Interact.exe" HelloWorldInteract.cs AssemblyInfo.cs
  cd ..

clean:
  del /s *.exe *.pdb *.dll