import { resolve as nodeResolve } from 'node:path';
import type { UserConfig } from 'vite';

export const resolve: UserConfig['resolve'] = {
	alias: {
		'@': nodeResolve(__dirname, './src')
	}
};
