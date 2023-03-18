export type Action1<TInput> = (input: TInput) => void;
export type Action2<TInput1, TInput2> = (input1: TInput1, input2: TInput2) => void;
export type Action3<TInput1, TInput2, TInput3> = (input1: TInput1, input2: TInput2, input3: TInput3) => void;