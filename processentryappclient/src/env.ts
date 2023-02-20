import React from 'react';

export const dev = window.location.origin.includes('localhost');
export const baseURL = dev ? 'https://localhost:7152' : '';
