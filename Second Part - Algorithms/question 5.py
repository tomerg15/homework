# Bonus question
from mpmath import *


def reverse_n_pi_digits(number):
    mp.dps = number
    return str(pi)[::-1]


x = int(input("Enter Natural Number: "))
print(reverse_n_pi_digits(x))
