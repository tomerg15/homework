# need to check: a^2 + b^2 = c^2, and that a < b < c, and that a + b + c = sum
def pythagorean_triplet_by_sum(sum):
    c = 0
    m = 2
    while c < sum:
        for n in range(1, m + 1):
            a = m * m - n * n
            b = 2 * m * n
            c = m * m + n * n
            if c > sum or a == 0 or b == 0 or c == 0 or a + b + c > sum:
                break
            if a + b + c == sum and a < b < c and a**2 + b**2 == c**2:
                print(a, ",", b, ",", c)
        m = m + 1


flag_natural_number = False
while not flag_natural_number:
    sum = (input("Enter a natural number: "))
    if sum.isdigit():
        flag_natural_number = True
        pythagorean_triplet_by_sum(int(sum))
