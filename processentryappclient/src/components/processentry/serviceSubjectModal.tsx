import { Modal, Button } from 'antd';
import { IModalProps } from '../../models/modalProps.type';

const serviceSubjectModal = ({
  isModalVisible,
  showModal,
  hideModal,
}: IModalProps) => {
  const handleOk = () => {
    // Do something when the user clicks the OK button
  };

  return (
    <Modal
      title="Service Subject"
      open={isModalVisible}
      onOk={handleOk}
      onCancel={hideModal}
    >
      <p>Some contents... servicesubject modal</p>
    </Modal>
  );
};

export default serviceSubjectModal;
