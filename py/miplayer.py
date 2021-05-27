import ctypes
import sys

# Load winmm.dll
dll = ctypes.WinDLL('winmm.dll')
SND_FILENAME = 0x20000
SND_NODEFAULT = 0x0002

def play_sound(path):
    bpath = path.encode()
    dll.PlaySound(bpath, None, SND_FILENAME | SND_NODEFAULT)

def main():
    args = sys.argv
    path = "C:\\Windows\\Media\\Windows Ding.wav" # Default
    if len(args) > 1:
        path = args[1]

    play_sound(path)

main()
