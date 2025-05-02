import { useRef } from "react";
import { mdiClose, mdiMinus, mdiWindowMaximize } from "@mdi/js";
import Icon from "@mdi/react";
import Draggable from "react-draggable";

interface PcModalProps {
  isOpen: boolean;
  onClose: () => void;
}

function PcModal({ isOpen, onClose }: PcModalProps) {
  const nodeRef = useRef<HTMLDivElement>(null);
  const pcSpecs = [
    {
      label: "GPU",
      value: "NVIDIA GeForce RTX 2070 8G",
    },
    {
      label: "CPU",
      value: "12th Gen Intel(R) Core(TM) i5-12400F",
    },
    {
      label: "Carte mère",
      value: "Gigabyte B760M DS3H DDR4 Micro ATX",
    },
    {
      label: "RAM",
      value: "16 Go Corsair LPX 16 GB DDR4-3200",
    },
    {
      label: "Boîtier",
      value: "MSI Mag Force 112R ATX",
    },
  ];

  if (!isOpen) return null;

  return (
    <Draggable
      handle=".xp-title-bar"
      nodeRef={nodeRef as React.RefObject<HTMLElement>}
    >
      <div ref={nodeRef} className="xp-window position-absolute p-2 mt-2 w-25">
        <div className="xp-title-bar d-flex justify-content-between align-items-center p-2 cursor-move">
          <span>Mon PC</span>
          <div>
            <button className="xp-title-button btn btn-sm p-0 mx-1">
              <Icon path={mdiMinus} size={0.6} />
            </button>
            <button className="xp-title-button btn btn-sm p-0 mx-1">
              <Icon path={mdiWindowMaximize} size={0.6} />
            </button>
            <button
              className="xp-title-button btn btn-sm p-0 mx-1 xp-close-button"
              onClick={onClose}
            >
              <Icon path={mdiClose} size={0.6} />
            </button>
          </div>
        </div>
        <div className="p-3">
          <table className="table table-bordered table-sm m-0 text-center">
            <tbody>
              {pcSpecs.map((spec, index) => (
                <tr key={index}>
                  <th scope="row">{spec.label}</th>
                  <td>{spec.value}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </Draggable>
  );
}

export default PcModal;
