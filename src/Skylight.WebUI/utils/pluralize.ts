import pluralize from 'pluralize';

export default function (
	word: MaybeRef<string>,
	number: MaybeRef<number>,
	inclusive?: boolean,
): string {
	return pluralize(unref(word), unref(number), inclusive);
}
