import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
//redux
import { Provider } from 'react-redux';
import { store } from './redux/app/store';
//toaster
import { Toaster } from 'react-hot-toast';
import { ThemeProvider } from '@emotion/react';
//mui theme
import { theme } from './Theme';

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <ThemeProvider theme={theme}>
        <Provider store={store}>
            <Toaster />
            <App />
        </Provider>
    </ThemeProvider>
);