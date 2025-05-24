import { $dt } from '@primeuix/themes';

export interface ChartColors {
	backgroundColors: Ref<string[]>;
	borderColors: Ref<string[]>;
	gridColor: Ref<string>;
	textColor: Ref<string>;

	getBackgroundColor: (index: number) => string;
	getBorderColor: (index: number) => string;
}

export default function (): ChartColors {
	const backgroundColors: Ref<string[]> = ref([
		$dt('sky.600').value,
		$dt('red.600').value,
		$dt('orange.600').value,
		$dt('yellow.600').value,
		$dt('green.600').value,
		$dt('blue.600').value,
		$dt('rose.600').value,
		$dt('lime.600').value,
		$dt('teal.600').value,
		$dt('slate.600').value,
	]);

	const borderColors: Ref<string[]> = ref([
		$dt('sky.500').value,
		$dt('red.500').value,
		$dt('orange.500').value,
		$dt('yellow.500').value,
		$dt('green.500').value,
		$dt('blue.500').value,
		$dt('rose.500').value,
		$dt('lime.500').value,
		$dt('teal.500').value,
		$dt('slate.500').value,
	]);

	const gridColor = useThemeColor('content.border.color').color;
	const textColor = useThemeColor('text.muted.color').color;

	const getBackgroundColor = (index: number): string =>
		backgroundColors.value[index % backgroundColors.value.length];
	const getBorderColor = (index: number): string =>
		borderColors.value[index % borderColors.value.length];

	return {
		backgroundColors,
		borderColors,
		gridColor,
		textColor,
		getBackgroundColor,
		getBorderColor,
	};
}
