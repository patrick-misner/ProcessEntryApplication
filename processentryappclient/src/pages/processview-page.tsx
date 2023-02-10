import React from 'react';
import { PageLayout } from '../components/page-layout';
import { useState } from 'react';
import { api } from '../services/AxiosService';

const ProcessviewPage: React.FC = () => {

  
    return (
    <PageLayout>
      <div className="container mx-auto mt-10 dark:bg-slate-500">
        <div className="grid grid-cols-12 gap-1">
          <div className="col-span-12 md:col-span-4">
          </div>
          <div className="col-span-12 md:col-span-4">
            <button className="bg-black hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">SpaceShip</button>
          </div>

        </div>
      
      </div>

      <div>
  <div>

        </div>
      </div>
      <div>
  <div>

        </div>
      </div>
      <div>
  <div>

        </div>
      </div>
    </PageLayout>

  );
}

export default ProcessviewPage; 
