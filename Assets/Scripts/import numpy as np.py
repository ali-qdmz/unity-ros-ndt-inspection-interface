import os
import numpy as np
import h5py



def read_dzt_file(filename):
    # Modify this placeholder to fit the actual format of your DZT files
    with open(filename, 'rb') as file:
        data = np.fromfile(file, dtype=np.uint16)  # or the correct dtype
    return data

def preprocess_data(raw_data, shape):
    # Normalize and reshape data
    max_val = np.max(raw_data)
    processed_data = (raw_data / max_val) * 255
    processed_data = np.reshape(processed_data, shape)
    return processed_data.astype(np.uint8)

dzt_directory = "C:/Users/Ali/Downloads/gpr2-download/Raw data_DZT/1.6 GHz/"

# List of all DZT files
dzt_files = [os.path.join(dzt_directory, f) for f in os.listdir(dzt_directory) if f.endswith('.DZT')]

# Ensure that we are processing exactly 30 files
assert len(dzt_files) == 30, "The number of DZT files in the directory is not equal to 30."

# Initialize an empty list to store each slice of processed data
all_data_slices = []

# Process each file and append to the list
for dzt_file in dzt_files:
    raw_data = read_dzt_file(dzt_file)
    processed_data = preprocess_data(raw_data, (512, 98))  # Adjust dimensions as per single DZT file
    all_data_slices.append(processed_data)


combined_data = np.stack(all_data_slices, axis=2)

combined_data = combined_data[:,:,0:15]



data = combined_data  # Replace this with your actual data loading code

# Function to save a 2D numpy array to an ASCII grid file
def save_to_ascii_grid(data_slice, filename):
    with open(filename, 'w') as file:
        file.write("ncols {}\n".format(data_slice.shape[0]))
        file.write("nrows {}\n".format(data_slice.shape[1]))
        file.write("xllcorner 0.0\n")
        file.write("yllcorner 0.0\n")
        file.write("cellsize 1.0\n")
        file.write("NODATA_value -9999\n")
        
        for row in data_slice:
            file.write(" ".join(map(str, row)) + "\n")

# Export each layer to a separate ASCII grid file
for i in range(data.shape[2]):
    filename = f"output_layer_{i+1}.asc"
    save_to_ascii_grid(data[:, :, i], "C:/Users/Ali/Downloads/gpr2-download/" + filename)
    print(f"Data layer {i+1} saved to {filename}")