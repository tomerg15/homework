import math


def num_len(num):
    return int(math.log10(num))+1


print(num_len(int(input("Enter an integer: "))))
