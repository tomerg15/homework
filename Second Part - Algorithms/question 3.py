def is_sorted_polyndrom(word):
    current_letter = word[0]
    for count, letter in enumerate(word[1:]):
        if ord(letter) < ord(current_letter) and count < int(len(word)/2):
            return False
        elif ord(letter) > ord(current_letter) and count > int(len(word)/2):
            return False
        current_letter = letter
    return word == word[::-1]


flag_valid_word = False
while not flag_valid_word:
    word = input("Enter a word: ")
    if word.isalpha():
        flag_valid_word = True
        print(is_sorted_polyndrom(word))
