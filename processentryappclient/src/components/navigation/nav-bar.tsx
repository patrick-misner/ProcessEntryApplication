import { useAuth0 } from "@auth0/auth0-react";
import React, { useState } from 'react';
import { FileAddFilled, DashboardFilled, SettingOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { useNavigate } from 'react-router-dom';
import { Menu } from 'antd';




const items: MenuProps['items'] = [
  {
    label: 'Dashboard',
    key: '/',
    icon: <DashboardFilled />,
  },
  {
    label: 'New Process Entry',
    key: '/processentry/new',
    icon: <FileAddFilled />,
    disabled: false,
  },
  {
    label: 'Process View',
    key: '/processview',
    icon: <FileAddFilled />,
    disabled: false,
  },
  
  {
    label: 'Navigation Three - Submenu',
    key: 'SubMenu',
    icon: <SettingOutlined />,
    children: [
      {
        type: 'group',
        label: 'Item 1',
        children: [
          {
            label: 'Option 1',
            key: 'setting:1',
          },
          {
            label: 'Option 2',
            key: 'setting:2',
          },
        ],
      },
      {
        type: 'group',
        label: 'Item 2',
        children: [
          {
            label: 'Option 3',
            key: 'setting:3',
          },
          {
            label: 'Option 4',
            key: 'setting:4',
          },
        ],
      },
    ],
  },
  {
    label: (
      <a href="https://ant.design" target="_blank" rel="noopener noreferrer">
        Navigation Four - Link
      </a>
    ),
    key: 'alipay',
  },
];




const NavBar: React.FC = () => {
  
  const [current, setCurrent] = useState('mail');
  const navigate = useNavigate();
  

  const onClick: MenuProps['onClick'] = (e) => {
    console.log('click ', e);
    setCurrent(e.key);
    navigate(e.key)
  };

  return (
    <div className="dark:bg-slate-900">
      <Menu className="dark:bg-slate-900 dark:text-white" onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items} />
    </div>
    );
};

export default NavBar;