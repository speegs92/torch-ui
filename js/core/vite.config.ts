import { defineConfig } from 'vite';

export default defineConfig({
	build: {
		lib: {
			entry: {
				'core': './src/index.ts'
			},
			formats: [ 'es' ]
		}
	}
});
