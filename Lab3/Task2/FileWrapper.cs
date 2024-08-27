using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Task2;

public class FileWrapper : IDisposable
{
    public SafeFileHandle _handle;
    private bool _disposed = false;
    
    public FileWrapper(string name)
    {
        _handle = CreateFile(name, 0, 0, 0, 0, 0, IntPtr.Zero);
    }

    public void Dispose()
    {
        if(_disposed) return;
        _disposed = true;
        _handle.Dispose();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CheckDisposed() 
    {
        if(_disposed) {
            throw new ObjectDisposedException("Handle", "This handle is already disposed.");
        }
    }
    
   [DllImport("kernel32.dll", EntryPoint = "CreateFile", SetLastError = true)]
    private static extern SafeFileHandle CreateFile(String lpFileName,
        UInt32 dwDesiredAccess, UInt32 dwShareMode,
        IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition,
        UInt32 dwFlagsAndAttributes,
        IntPtr hTemplateFile);
}