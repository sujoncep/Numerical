def f(x):
    return x**3 - x - 1

def first_derivative(x):
    h = 0.000001
    slope = (f(x +h) - f(x)) / h
    return slope

def second_derivative(x):
    h = 0.000001
    slope = (first_derivative(x+h) - first_derivative(x)) / h
    return slope

def halley(x):
    t = x - (2*f(x)*first_derivative(x)) / (2*first_derivative(x)**2 - first_derivative(x)*second_derivative(x))
    return t

if f(0) >= 0:
    flag_one = 0
else:
    flag_one = 1

flag_two = flag_one
a = 0
i = 0
while flag_one == flag_two:
    if f(i) >= 0:
        flag_two = 0
    else:
        flag_two = 1
    if flag_one == flag_two:
        a = i
    i += 1
t_new = halley(a)
while 1:
    t_prev = t_new
    t_new = halley(t_prev)
    if t_prev >= t_new:
        if t_prev - t_new <= 0.0001:
            break
    else:
        if t_new - t_prev <= 0.0001:
            break
print(t_new)
