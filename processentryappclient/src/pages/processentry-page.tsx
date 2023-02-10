import React from 'react'
import { PageLayout } from '../components/page-layout'
import { Input, InputNumber, Button } from 'antd';




const ProcessentryPage = () => {

  return (
    <PageLayout>
      <div className="container mx-auto mt-10 dark:bg-slate-900 dark:text-white">
        <form>
          <div className="grid grid-cols-12 gap-1">

            <div className="col-span-12 text-center">
              Process Entry
            </div>

            <div className="col-span-12 md:col-span-6 p-3">
              Client Reference:
              <Input className="mb-2 dark:bg-slate-500 dark:text-white" placeholder="Client Reference" />
              <p>Court Id:</p>
              <InputNumber className="mb-2 dark:bg-slate-500 dark:text-white" min={1} max={100000} defaultValue={1} />

            </div>
            <div className="col-span-12 md:col-span-6 p-3">
              Form stuff
              <div className="flex flex-col justify-end h-full">
                <div className="">
                  <Button htmlType="submit" className="dark:bg-black dark:text-white mb-4">Submidt</Button>
                </div>

              </div>
            </div>


          </div>
        </form>
        <div>

        </div>
      </div>
    </PageLayout>

  )
}

export default ProcessentryPage;