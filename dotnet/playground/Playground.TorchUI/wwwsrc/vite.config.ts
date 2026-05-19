import { resolve } from 'node:path';
import { defineConfig } from 'vite';

export default defineConfig({
	resolve: {
		alias: {
			'@': resolve(__dirname, './src'),
			'@torchui/core': resolve(__dirname, '../../../../js/core/src/index.ts')
		}
	}
});
