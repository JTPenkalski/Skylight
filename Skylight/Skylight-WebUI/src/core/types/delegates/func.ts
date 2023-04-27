export type Func<TOutput> = () => TOutput;
export type Func1<TInput, TOutput> = (input: TInput) => TOutput;
export type Func2<TInput1, TInput2, TOutput> = (input1: TInput1, input2: TInput2) => TOutput;
export type Func3<TInput1, TInput2, TInput3, TOutput> = (input1: TInput1, input2: TInput2, input3: TInput3) => TOutput;