## Firebase

*Tools*

```bash
npm install -g firebase-tools
firebase init
```

*Functions*

```bash
npm --prefix functions install
npm --prefix functions run build
```

*Host*

```bash
npm --prefix client install --save-dev \
    firebase \
    parcel-bundler \
    typescript \
    react react-dom \
    @types/react @types/react-dom

npm --prefix client audit fix
npm --prefix client run build
npm --prefix client run watch
```

*Deploy*

```bash
firebase deploy --only hosting
```