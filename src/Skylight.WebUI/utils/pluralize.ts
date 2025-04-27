export default function (text: string, amount: MaybeRef<number>): string {
	const normalizedAmount = Math.abs(unref(amount));

	return normalizedAmount === 1 ? text : `${text}s`;
}
