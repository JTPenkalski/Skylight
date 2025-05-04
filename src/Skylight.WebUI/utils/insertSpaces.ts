export default function (word: MaybeRef<string>): string {
	return unref(word)
		.replace(/([A-Z])/g, ' $1')
		.trim();
}
