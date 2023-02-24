import React, { useEffect, useState } from 'react';
import {
  FileAddFilled,
  DashboardFilled,
  SettingOutlined,
} from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { useNavigate } from 'react-router-dom';
import { Menu } from 'antd';
import { useAuth0 } from '@auth0/auth0-react';

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
];

const NavBar: React.FC = () => {
  const [current, setCurrent] = useState('mail');
  const [menuItems, setMenuItems] = useState(items);
  const navigate = useNavigate();
  const auth0 = useAuth0();

  useEffect(() => {
    if (auth0.user) {
      setMenuItems((prevState) => [
        ...prevState,
        {
          label: auth0.user?.email,
          key: '/profile',
          icon: <FileAddFilled />,
          disabled: false,
        },
      ]);
    }
  }, [auth0.user]);

  const onClick: MenuProps['onClick'] = (e) => {
    console.log('click ', e);
    setCurrent(e.key);
    navigate(e.key);
  };

  return (
    <div className="dark:bg-slate-900">
      <Menu
        className="dark:bg-slate-900 dark:text-white"
        onClick={onClick}
        selectedKeys={[current]}
        mode="horizontal"
        items={menuItems}
      />
    </div>
  );
};

export default NavBar;
