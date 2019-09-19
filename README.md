## Firebase

```bash
npm install -g firebase-tools
npm --prefix functions install
npm --prefix functions run build
npm --prefix functions run deploy
```

*Update*

```bash
npm --prefix functions install --save-dev typescript@3.6.3
npm --prefix functions install --save-dev firebase-admin@latest
npm --prefix functions install --save-dev firebase-functions@latest

npm --prefix functions uninstall tslint --save-dev
npm --prefix functions   install tslint --save-dev
```