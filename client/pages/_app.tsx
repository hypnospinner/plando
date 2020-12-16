import React from 'react';
import '~antd/dist/antd.css';
import { AppProps } from 'next/app';
import { Provider } from 'react-redux';
import { Layout } from 'antd';
import Store from '@redux/store';

export interface IAppProps extends AppProps {}

function App({ Component, pageProps }: AppProps): JSX.Element {
  // TODO: put here const imported initial state
  return (
    <Provider store={Store}>
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </Provider>
  );
}

export default App;
