export default function (text: string, amount: number): string {
	const normalizedAmount = Math.abs(amount);

	return normalizedAmount === 1 ? text : `${text}s`;
}
