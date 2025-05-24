import { $dt } from '@primeuix/themes';

export default function (token: MaybeRef<string>): { color: Ref<string> } {
	const isDarkMode = true;

	const value = $dt(unref(token)).value;
	const color = isDarkMode ? value.dark.value : value.light.value;

	return { color };
}
