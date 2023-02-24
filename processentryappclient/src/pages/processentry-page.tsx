import React, { useEffect, useState } from 'react';
import { Input, InputNumber, Select, Tooltip, Button } from 'antd';
import Axios from 'axios';
import PageLayout from '../components/page-layout';
import { IProcessData } from '../models/process.type';
import { ICourtData } from '../models/courts.type';

const ProcessentryPage = () => {
  const [formData, setFormData] = useState<IProcessData | undefined>(undefined);
  const [courtList, setCourtList] = useState<ICourtData[]>([]);

  useEffect(() => {
    const fetchCourts = async () => {
      try {
        const response = await Axios.get<ICourtData[]>(
          'https://localhost:7152/api/courts'
        );
        setCourtList(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchCourts();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleNumberChange = (value: number | null, key: string) => {
    setFormData((prevState) => ({
      ...prevState,
      [key]: value,
    }));
  };

  const onChange = (value: string) => {
    console.log(`selected ${value}`);
  };

  const onSearch = (value: string) => {
    console.log('search:', value);
  };

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(formData);
  };

  return (
    <PageLayout>
      <div className="container mx-auto mt-10 dark:bg-slate-900 dark:text-white">
        <form onSubmit={onSubmit}>
          <div className="grid grid-cols-12 gap-1">
            <div className="col-span-12 text-center">Process Entry</div>

            <div className="col-span-12 md:col-span-6 p-3">
              Client Reference:
              <Input
                id="clientRef"
                className="mb-2 dark:bg-slate-500 dark:text-white"
                placeholder="Client Reference"
                value={formData?.clientRef}
                onChange={handleChange}
              />
              <p>Court Id:</p>
              <InputNumber
                id="courtId"
                value={formData?.courtId}
                className="mb-2 dark:bg-slate-500 dark:text-white"
                onChange={(value) => handleNumberChange(value, 'courtId')}
              />
              <Select
                showSearch
                placeholder="Select a person"
                optionFilterProp="children"
                onChange={onChange}
                onSearch={onSearch}
                filterOption={(input, option) =>
                  (option?.label ?? '')
                    .toLowerCase()
                    .includes(input.toLowerCase())
                }
                options={[
                  {
                    value: 'jack',
                    label: 'Jack',
                  },
                  {
                    value: 'lucy',
                    label: 'Lucy',
                  },
                  {
                    value: 'tom',
                    label: 'Tom',
                  },
                ]}
              />
            </div>
            <div className="col-span-12 md:col-span-6 p-3">
              Form stuff
              <div className="flex flex-col justify-end h-full">
                <div className="">
                  <Button
                    htmlType="submit"
                    className="dark:bg-black dark:text-white mb-4"
                  >
                    Submidttt
                  </Button>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    </PageLayout>
  );
};

export default ProcessentryPage;
