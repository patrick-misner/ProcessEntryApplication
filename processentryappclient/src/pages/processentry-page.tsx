import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import type { DatePickerProps } from 'antd';
import { Input, notification, DatePicker, Select, Button } from 'antd';
import PageLayout from '../components/page-layout';
import { IProcessData } from '../models/process.type';
import { IFormData } from '../models/formData.type';
import { api } from '../services/AxiosService';

const ProcessentryPage = () => {
  const [formData, setFormData] = useState<IProcessData | undefined>(undefined);
  const [formAssociatedData, setFormAssociatedData] = useState<IFormData>();
  const params = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    fetchFormAssociatedData();
    if (params.id) {
      fetchProcessData(params.id);
    }
  }, [params.id]);

  const fetchFormAssociatedData = async () => {
    try {
      const response = await api.get<IFormData>('/api/processentryformdata/');
      setFormAssociatedData(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const fetchProcessData = async (id: string) => {
    try {
      const response = await api.get<IProcessData>(`/api/processentries/${id}`);
      setFormData((current) => ({
        ...current,
        ...response.data,
      }));
    } catch (e) {
      notification.error({ message: 'Oh no ' });
    }
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleValueChange = (value: number | string | null, key: string) => {
    setFormData((prevState) => ({
      ...prevState,
      [key]: value,
    }));
  };

  const handleExpiredDateChange: DatePickerProps['onChange'] = (
    date,
    dateString
  ) => {
    const key = 'expireDateTime';
    setFormData((prevState) => ({
      ...prevState,
      [key]: dateString,
    }));
  };

  // const handleBlur = (event: React.FocusEvent<HTMLSelectElement>) => {
  //   const { value } = event.target.id;
  //   setFormData((prevState) => ({
  //     ...prevState,
  //     [event.target.id]: value,
  //   }));
  //   console.log(value, 'handleblur');
  // };

  const onSearch = (value: string) => {
    console.log('search:', value);
  };

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(formData);
    try {
      const response = await api.post<IProcessData>(
        '/api/processentries',
        formData
      );
      console.log('post response', response.data);
      if (response.data.id) {
        notification.success({
          message: 'Success!',
          description: 'process has been inserted into you database',
        });
        navigate(`/processentry/${response.data.id?.toString()}`);
      }
    } catch (error) {
      console.error(error);
    }
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
              <p>Court Name:</p>
              {Array.isArray(formAssociatedData?.courts) && (
                <Select
                  id="courtId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select a court"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'courtId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.courts.map((court) => ({
                    label: court.name,
                    value: court.id,
                  }))}
                  value={formData?.courtId}
                />
              )}
              <p>Case number:</p>
              <Input
                id="caseNum"
                className="mb-2 dark:bg-slate-500 dark:text-white"
                placeholder="Case Number"
                value={formData?.caseNum}
                onChange={handleChange}
              />
              <p>Priority:</p>
              <Select
                defaultValue="Routine"
                style={{ width: '50%' }}
                onChange={(value: string) =>
                  handleValueChange(value, 'priority')
                }
                options={[
                  { value: 'Routine', label: 'Routine' },
                  { value: 'ASAP', label: 'ASAP' },
                  { value: 'Rush', label: 'Rush' },
                  { value: 'Rush 24 Hours', label: 'Rush 24 Hours' },
                  { value: 'Rush 48 Hours', label: 'Rush 48 Hours' },
                ]}
                value={formData?.priority}
              />
              <p>Compliance Date:</p>
              <DatePicker onChange={handleExpiredDateChange} />
              <p>Plaintiff Type:</p>
              {Array.isArray(formAssociatedData?.litigantTypes) && (
                <Select
                  showSearch
                  placeholder="Select plaintiff type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  onChange={(value: number) =>
                    handleValueChange(value, 'plaintiffTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.litigantTypes.map(
                    (litigantType) => ({
                      label: litigantType.name,
                      value: litigantType.id,
                    })
                  )}
                  value={formData?.plaintiffTypeId}
                />
              )}
              <p>Defendant Type:</p>
              {Array.isArray(formAssociatedData?.litigantTypes) && (
                <Select
                  showSearch
                  placeholder="Select defendant type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  onChange={(value: number) =>
                    handleValueChange(value, 'defendantTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.litigantTypes.map(
                    (litigantType) => ({
                      label: litigantType.name,
                      value: litigantType.id,
                    })
                  )}
                  value={formData?.defendantTypeId}
                />
              )}
              <p>Received Date:</p>
              <p>Document to serve:</p>
              {Array.isArray(formAssociatedData?.documents) && (
                <Select
                  id="documentId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select document"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'documentId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.documents.map((document) => ({
                    label: document.name,
                    value: document.id,
                  }))}
                  value={formData?.documentId}
                />
              )}
              <p>Service Instructions:</p>
              {Array.isArray(formAssociatedData?.instructions) && (
                <Select
                  id="instructionId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select instructions"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'instructionId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.instructions.map(
                    (instruction) => ({
                      label: instruction.name,
                      value: instruction.id,
                    })
                  )}
                  value={formData?.instructionId}
                />
              )}
              <p>Server name:</p>
              {Array.isArray(formAssociatedData?.servers) && (
                <Select
                  id="serverId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select process server"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'serverId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.servers.map((server) => ({
                    label: server.name,
                    value: server.id,
                  }))}
                  value={formData?.serverId}
                />
              )}
              -----------
              <h2>Return Fields</h2>
              -----------
              <p>Served Date:</p>
              <p>Method of service:</p>
              {Array.isArray(formAssociatedData?.methods) && (
                <Select
                  id="methodId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select method of service"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'methodId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.methods.map((method) => ({
                    label: method.name,
                    value: method.id,
                  }))}
                  value={formData?.methodId}
                />
              )}
              <p>Served Capacity:</p>
              {Array.isArray(formAssociatedData?.capacities) && (
                <Select
                  id="capacityId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select served capacity"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'capacityId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.capacities.map((capacity) => ({
                    label: capacity.name,
                    value: capacity.id,
                  }))}
                  value={formData?.capacityId}
                />
              )}
              <p>Affidavit Type:</p>
              {Array.isArray(formAssociatedData?.affidavitTypes) && (
                <Select
                  id="affidavitTypeId"
                  tabIndex={0}
                  showSearch
                  placeholder="Select Affidavit Type"
                  optionFilterProp="children"
                  style={{ width: '100%' }}
                  // onBlur={handleBlur}
                  onChange={(value: number) =>
                    handleValueChange(value, 'affidavitTypeId')
                  }
                  onSearch={onSearch}
                  filterOption={(input, option) =>
                    (option?.label ?? '')
                      .toLowerCase()
                      .includes(input.toLowerCase())
                  }
                  options={formAssociatedData?.affidavitTypes.map(
                    (affidavitType) => ({
                      label: affidavitType.name,
                      value: affidavitType.id,
                    })
                  )}
                  value={formData?.affidavitTypeId}
                />
              )}
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
