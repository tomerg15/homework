import matplotlib.pyplot as plt
from scipy.stats import pearsonr

numbers_list = []
number = 0

number = float(input("Enter a number: "))
while number != -1:
    numbers_list.append(number)
    number = float(input("Enter a number: "))

print("List: ", numbers_list)
print("Average: ", sum(numbers_list) / len(numbers_list))
print("Positive numbers: ", sum([1 for x in numbers_list if x > 0]))
unsorted_numbers_list = numbers_list
print("Sorted list: ", sorted(numbers_list))

# Bonus Pearson
x_axis = [x for x in range(len(unsorted_numbers_list))]
pearson_number = str(pearsonr(x_axis, unsorted_numbers_list))[25:].split()
print("Pearson Correlation Value:", pearson_number[0].replace(",", ""))

# Bonus graph
fig = plt.figure()
ax = fig.add_subplot()
fig.suptitle('Scatter Graph Of Input Numbers', fontsize=14, fontweight='bold')
ax.set_title('axes title')
ax.set_xlabel('X AXIS')
ax.set_ylabel('Y AXIS (Numbers)')
plt.scatter(x_axis, unsorted_numbers_list)
plt.show()
plt.close()
