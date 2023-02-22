import React, { useState } from 'react';
import { Input, Tooltip, Button } from 'antd';
import PageLayout from '../components/page-layout';
import { IProcessData } from '../models/process.type';

const ProcessentryPage = () => {
  const [formData, setFormData] = useState<IProcessData | undefined>(undefined);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
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
              <Input
                id="courtId"
                value={formData?.courtId}
                className="mb-2 dark:bg-slate-500 dark:text-white"
                onChange={handleChange}
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
