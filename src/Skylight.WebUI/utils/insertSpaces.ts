export default function (word: MaybeRef<string>): string {
	return unref(word)
		.replace(/([a-z])([A-Z][a-z])/g, '$1 $2')
		.trim();
}
