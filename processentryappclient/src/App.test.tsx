import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';
import { api } from './services/AxiosService';

test('renders learn react link', () => {
  const fetchData = () =>
    api
      .get('/api/processentries/6007')
      .then((response) => console.log(response.data));

  fetchData();
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
