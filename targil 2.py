import math


def twitter_towers():
    num = 0
    choices = [1, 2, 3]
    while num != 3:
        # loop until the input is 1/2/3
        while num not in choices:
            num = int(input("Please enter your choice:\n "
                            "1 for rectangle\n "
                            "2 for triangle\n "
                            "3 to exit\n"))
        if num == 2 or num == 1:
            height = int(input("Please enter a height:\n"))
            width = int(input("Please enter a width:\n"))
        # handles the rectangle choice
        if num == 1:
            # if the rectangle is a square or the rectangles' sides have a difference larger than 5, print its' area
            if height == width or abs(height - width) > 5:
                print("The rectangle's area is: ")
                print(height * width)
                num = 0
            else:
                print("The rectangle's scope is: ")
                print((height * 2) + (width * 2))
                num = 0
        # handles the triangle choice
        elif num == 2:
            choice = 0
            # loop until the input is 1/2
            while choice != 1 and choice != 2:
                choice = int(input("Please enter your choice:\n"
                                   "1 for calculating triangle's scope\n"
                                   "2 for printing the triangle\n"))
            if choice == 1:
                # calculates the triangle's side using the pythagorean theorem, then prints the triangle's scope
                half_width = width / 2
                pow_side = pow(half_width, 2) + pow(height, 2)
                side = math.sqrt(pow_side)
                print("The triangle's scope is: ")
                print((side * 2) + width)
                num = 0
            else:
                # checks if the triangle can be printed or not
                if (width % 2 == 0) or (width > height * 2):
                    print("The system cannot print the triangle\n")
                else:
                    if width == 1:
                        for row in range(1, height + 1):
                            print('*')
                    elif width == 3:
                        for row in range(1, height):
                            print(' ' + '*')
                        print('*' * width)

                    else:
                        # print first row
                        print(' ' * (width // 2) + '*')

                        # calculate number of blocks of rows
                        num_of_blocks = (width - 2) // 2

                        # calc num of rows in each block
                        num_of_rows = (height - 2) // num_of_blocks
                        first_block = num_of_rows + ((height - 2) % num_of_blocks)
                        i = 3
                        j = 1

                        # print first block
                        for row in range(1, first_block + 1):
                            print((' ' * ((width // 2) - j)) + '*' * i)

                        # print the rest of blocks
                        for block in range(1, num_of_blocks):
                            i += 2
                            j += 1
                            print_row = (' ' * ((width // 2) - j)) + '*' * i
                            for row in range(1, num_of_rows + 1):
                                print(print_row)

                        # print last row
                        print('*' * width)
                num = 0
    return

twitter_towers()
