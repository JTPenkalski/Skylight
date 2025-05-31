import pluralize from 'pluralize';

export default function (word: MaybeRef<string>): string {
	return pluralize.plural(unref(word));
}
